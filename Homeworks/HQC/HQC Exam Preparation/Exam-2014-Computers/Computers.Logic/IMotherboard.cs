namespace Computers.Logic
{
    /// <summary>
    /// Represents motherboard functionality.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads value from the RAM.
        /// </summary>
        /// <returns>The loaded value.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves a given value in the RAM.
        /// </summary>
        /// <param name="value">The value to be saved.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws on the Video Card.
        /// </summary>
        /// <param name="data">Text to draw.</param>
        void DrawOnVideoCard(string data);
    }
}
