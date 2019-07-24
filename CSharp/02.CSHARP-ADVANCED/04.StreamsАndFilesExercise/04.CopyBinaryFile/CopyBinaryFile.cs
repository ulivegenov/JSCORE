using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream sourceFile = new FileStream("../Resources/copyMe.png", FileMode.Open))
            {
                using (FileStream resultFile = new FileStream("resultCopy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytesCounte = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytesCounte == 0)
                        {
                            break;
                        }

                        resultFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
