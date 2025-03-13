using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WavFiles
{
    class WAVPlayer
    {
        // Play a WAV file
        static SoundPlayer player = new SoundPlayer();
        static string[] wavFiles = { @"C:\Users\Seth\Downloads\Travis Scott - sdp interlude (Extended) [ ezmp3.cc ].wav",
                                     @"C:\Users\Seth\Downloads\Kanye West - I Wonder (Extended Intro) [ ezmp3.cc ].wav",
                                     @"C:\Users\Seth\Downloads\Tory Lanez _Say It_ (Audio) [ ezmp3.cc ].wav" }; // List of WAV files
        static int currentPlaying = -1; // Track currently playing file (-1 means none)

        public static void FilePlayer ()
        {
            Console.WriteLine("Welcome to the WAV Player!");

            while (true)
            {
                DisplayMenu();
                Console.Write("\nChoose a file to play (1-3) or 4 to Stop, 5 to Exit: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    WAVPlayer.player.Stop();
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                }
                else if (choice == "4")
                {
                    WAVPlayer.player.Stop();
                    currentPlaying = -1;
                    Console.WriteLine("Playback stopped.");
                } 
                else if (int.TryParse(choice, out int index) && index >= 1 && index <= 3)
                {
                    PlayWav(index - 1);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\n==== WAV Player ====\n");

            for (int wav = 0; wav < wavFiles.Length; wav++)
            {
                if (wav == currentPlaying)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Highlight currently playing track
                    Console.WriteLine($"▶ {wav + 1}. {wavFiles[wav]} (Playing)");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {wav + 1}. {wavFiles[wav]}");
                }
            }

            Console.WriteLine("\n  4. Stop Playback");
            Console.WriteLine("  5. Exit");
        }

        static void PlayWav(int index)
        {
            try
            {
                player.SoundLocation = wavFiles[index];
                player.Play();
                currentPlaying = index; // Update currently playing track
                Console.WriteLine($"Now playing: {wavFiles[index]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }


    }
}
