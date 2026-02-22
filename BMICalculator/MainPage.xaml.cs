namespace BMICalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        UpdateCategoryChips(null);
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
        UpdateCategoryChips(category);
    }
    
    //Show nothing for BMI and Category
    //Display the error messages
    private void ShowInputError(string message)
    {
        BmiResultLabel.Text = "BMI: -";
        CategoryLabel.Text = "Category: -";
        MessageLabel.Text = message;
        UpdateCategoryChips(null);
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

    private void UpdateCategoryChips(string? activeCategory)
    {
        SetChipState(UnderweightChip, activeCategory == "Underweight");
        SetChipState(NormalWeightChip, activeCategory == "Normal weight");
        SetChipState(OverweightChip, activeCategory == "Overweight");
        SetChipState(ObesityChip, activeCategory == "Obesity");
    }

    private static void SetChipState(Border chip, bool isActive)
    {
        if (isActive)
        {
            chip.BackgroundColor = Color.FromArgb("#FDBA74");
            chip.Stroke = Color.FromArgb("#FB923C");
            return;
        }

        chip.BackgroundColor = Color.FromArgb("#F8FAFC");
        chip.Stroke = Color.FromArgb("#CBD5E1");
    }
}
