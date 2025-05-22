using System;

public class Fraction
{
    // Private attributes to store the numerator (top) and denominator (bottom) of the fraction.
    // These are private to encapsulate the internal representation of the fraction,
    // meaning direct access from outside the class is prevented.
    private int _top;
    private int _bottom;

    /// <summary>
    /// Constructor that has no parameters.
    /// Initializes the fraction to 1/1 as a default value.
    /// </summary>
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    /// <summary>
    /// Constructor that has one parameter for the top number.
    /// Initializes the denominator to 1, effectively creating a whole number fraction (e.g., 5/1).
    /// </summary>
    /// <param name="top">The numerator of the fraction.</param>
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1; // Default denominator when only the top is provided.
    }

    /// <summary>
    /// Constructor that has two parameters, one for the top and one for the bottom.
    /// Allows full initialization of the fraction.
    /// </summary>
    /// <param name="top">The numerator of the fraction.</param>
    /// <param name="bottom">The denominator of the fraction.</param>
    public Fraction(int top, int bottom)
    {
        _top = top;
        // Ensure the denominator is not zero. If zero, default to 1 and print a warning.
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Warning: Denominator cannot be zero. Setting to 1.");
            _bottom = 1;
        }
    }

    /// <summary>
    /// Public getter method for the top number (numerator).
    /// Provides controlled access to the private _top attribute.
    /// </summary>
    /// <returns>The integer value of the numerator.</returns>
    public int GetTop()
    {
        return _top;
    }

    /// <summary>
    /// Public setter method for the top number (numerator).
    /// Allows modification of the private _top attribute.
    /// </summary>
    /// <param name="top">The new integer value for the numerator.</param>
    public void SetTop(int top)
    {
        _top = top;
    }

    /// <summary>
    /// Public getter method for the bottom number (denominator).
    /// Provides controlled access to the private _bottom attribute.
    /// </summary>
    /// <returns>The integer value of the denominator.</returns>
    public int GetBottom()
    {
        return _bottom;
    }

    /// <summary>
    /// Public setter method for the bottom number (denominator).
    /// Allows modification of the private _bottom attribute, with a check to prevent zero denominator.
    /// </summary>
    /// <param name="bottom">The new integer value for the denominator.</param>
    public void SetBottom(int bottom)
    {
        // Prevent setting the denominator to zero, which would cause a division by zero error.
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Warning: Denominator cannot be zero. Value remains unchanged.");
            // Optionally, you could throw an exception or set a default value here.
        }
    }

    /// <summary>
    /// Returns a string representation of the fraction in "top/bottom" format.
    /// </summary>
    /// <returns>A string like "3/4".</returns>
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    /// <summary>
    /// Calculates and returns the decimal value of the fraction.
    /// </summary>
    /// <returns>A double representing the result of dividing the top by the bottom.</returns>
    public double GetDecimalValue()
    {
        // Cast to double to ensure floating-point division.
        return (double)_top / (double)_bottom;
    }
}
