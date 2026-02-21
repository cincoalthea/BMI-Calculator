namespace BMICalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculateBmiClicked(object? sender, EventArgs e)
    {
        MessageLabel.Text = string.Empty;

        if (!double.TryParse(WeightEntry.Text, out var weightKg) || weightKg <= 0)
        {
            ShowInputError("Please enter a valid weight in kilograms.");
            return;
        }

        if (!double.TryParse(HeightEntry.Text, out var heightCm) || heightCm <= 0)
        {
            ShowInputError("Please enter a valid height in centimeters.");
            return;
        }

        var heightMeters = heightCm / 100.0;
        var bmi = weightKg / (heightMeters * heightMeters);
        var category = GetBmiCategory(bmi);

        BmiResultLabel.Text = $"BMI: {bmi:F1}";
        CategoryLabel.Text = $"Category: {category}";
    }

    private void ShowInputError(string message)
    {
        BmiResultLabel.Text = "BMI: -";
        CategoryLabel.Text = "Category: -";
        MessageLabel.Text = message;
    }

    private static string GetBmiCategory(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        if (bmi < 25)
            return "Normal weight";
        if (bmi < 30)
            return "Overweight";
        return "Obesity";
    }
}
