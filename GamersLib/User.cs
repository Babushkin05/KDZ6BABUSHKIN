using System;

namespace GamersLib
{
    /// <summary>
    /// Class to take info from a user.
    /// </summary>
	public static class User
	{
        /// <summary>
        /// Gets name of file.
        /// </summary>
        /// <returns>Name of file.</returns>
		internal static string? GetNameOfJson()
		{
			Console.Clear();
			string? path;
            do
            {
                Console.Write("Type path for the file (without '.json') :: ");
                path = Console.ReadLine();
            } while (!IsCorrectFileName(path));

            Console.Clear();

            return path;
		}

        /// <summary>
        /// Returns is file name correct.
        /// </summary>
        /// <param name="name">Name of file.</param>
        /// <returns>Is this file name correct</returns>
        private static bool IsCorrectFileName(string? name)
        {
            // Checking invalid chars in name.
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char chr in name)
            {
                if (invalidChars.Contains(chr))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

