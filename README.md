AlphaVSS
========

AlphaVSS is a .NET class library released under the MIT license providing a managed API for the Volume Shadow Copy Service also known as VSS. The Volume Shadow Copy Service is a set of COM interfaces that implements a framework to allow volume backups to be performed while applications on a system continue to write to the volumes.

AlphaVSS, written in C# and C++/CLI provides a managed interface to this API.

The goal of AlphaVSS is to provide an interface that is simple to use from any .NET application, yet provides the full functionality of VSS.

For more information see [http://alphavss.alphaleonis.com](http://alphavss.alphaleonis.com)




FileStream inf = new FileStream("path1", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream outf = new FileStream("path2", FileMode.Create);
            int a;
            while ((a = inf.ReadByte()) != -1)
            {
                outf.WriteByte((byte)a);
            }
            inf.Close();
            inf.Dispose();
            outf.Close();
            outf.Dispose();
