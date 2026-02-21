namespace BMICalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    //When button "Calculate BMI" is clicked
    private void OnCalculateBmiClicked(object? sender, EventArgs e)
    {
        MessageLabel.Text = string.Empty; //Will clear old error text
        
        //Get input
        //If no input, return error message using ShowInputError and pass the message.
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
        
        //Calculate for height, BMI
        //Get its BMI category using GetBmiCategory and pass the calculated BMI
        var heightMeters = heightCm / 100.0;
        var bmi = weightKg / (heightMeters * heightMeters);
        var category = GetBmiCategory(bmi);
        
        //Replace the text to be displayed for the BMI result and category
        BmiResultLabel.Text = $"BMI: {bmi:F1}";
        CategoryLabel.Text = $"Category: {category}";
    }
    
    //Show nothing for BMI and Category
    //Display the error messages
    private void ShowInputError(string message)
    {
        BmiResultLabel.Text = "BMI: -";
        CategoryLabel.Text = "Category: -";
        MessageLabel.Text = message;
    }

    //Calculate BMI Category (Underweight, Normal weight, Overweight, and Obese) and return it
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
