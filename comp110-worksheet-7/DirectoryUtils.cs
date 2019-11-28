using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
		// Return the size, in bytes, of the given file
		public static long GetFileSize(string filePath)
		{
			return new FileInfo(filePath).Length;
		}

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
            long totalSize = 0;
            Stack<string> subDirectories = new Stack<string>();

            if (IsDirectory(directory))
            {
                subDirectories.Push(directory);

                while (subDirectories.Count > 0)
                {
                    string currentDirectory = subDirectories.Pop();
                    string[] newDirectories = Directory.GetDirectories(currentDirectory);

                    for (int i = 0; i < newDirectories.Length; i++)
                    {
                        subDirectories.Push(newDirectories[i]);
                    }

                    string[] newFiles = Directory.GetFiles(currentDirectory);

                    for (int i = 0; i < newFiles.Length; i++)
                    {
                        totalSize += GetFileSize(newFiles[i]);
                    }
                }
            }

            return totalSize;
		}

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{
            int fileCount = 0;

            Stack<string> subDirectories = new Stack<string>();

            if (IsDirectory(directory))
            {
                subDirectories.Push(directory);

                while (subDirectories.Count > 0)
                {
                    string currentDirectory = subDirectories.Pop();
                    string[] newDirectories = Directory.GetDirectories(currentDirectory);

                    for (int i = 0; i < newDirectories.Length; i++)
                    {
                        subDirectories.Push(newDirectories[i]);
                    }

                    string[] newFiles = Directory.GetFiles(currentDirectory);

                    for (int i = 0; i < newFiles.Length; i++)
                    {
                        fileCount++;
                    }
                }
            }

            return fileCount;
        }

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            int depth = 0;

            Stack<string> currentDirectories = new Stack<string>();
            Stack<string> subDirectories = new Stack<string>();

            if (IsDirectory(directory))
            {
                currentDirectories.Push(directory);

                while(currentDirectories.Count > 0)
                {
                    for (int i = 0; i < currentDirectories.Count; i++)
                    {
                        string[] newDictionaries = Directory.GetDirectories(currentDirectories.Pop());

                        for (int j = 0; j < newDictionaries.Length; j++)
                        {
                            subDirectories.Push(newDictionaries[j]);
                        }
                    }

                    if (subDirectories.Count > 0)
                    {
                        currentDirectories.Clear();

                        for (int i = 0; i < subDirectories.Count; i++)
                        {
                            currentDirectories.Push(subDirectories.Pop());
                        }

                        subDirectories.Clear();
                        depth++;
                    }                    
                }
            }

            return depth;
		}

        // Get the path and size (in bytes) of the smallest file below the given directory
        public static Tuple<string, long> GetSmallestFile(string directory)
        {
            Tuple<String, long> smallestFile = new Tuple<string, long>("notFound", 0);

            Stack<string> subDirectories = new Stack<string>();

            if (IsDirectory(directory))
            {
                subDirectories.Push(directory);

                while (subDirectories.Count > 0)
                {
                    string currentDirectory = subDirectories.Pop();
                    string[] newDirectories = Directory.GetDirectories(currentDirectory);

                    for (int i = 0; i < newDirectories.Length; i++)
                    {
                        subDirectories.Push(newDirectories[i]);
                    }

                    string[] newFiles = Directory.GetFiles(currentDirectory);


                }

                return smallestFile;
            }
        }

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
			throw new NotImplementedException();
		}

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
			throw new NotImplementedException();
		}
	}
}
