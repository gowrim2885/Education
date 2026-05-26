
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpBasics
{
    public class DataTypeLab
    {
 
            public static void FindDatatype()
            {
                Console.WriteLine("========= BYTE & SBYTE =========");

                byte b = 65;   // Valid (0 to 255)
                Console.WriteLine($"Byte Value: {b}");
                Console.WriteLine($"ASCII Character: {(char)b}");
                Console.WriteLine($"Byte Min: {byte.MinValue}, Max: {byte.MaxValue}");
                Console.WriteLine($"Byte Size: {sizeof(byte)}");

                // byte bError1 = -10;     //  byte cannot store negative
                // byte bError2 = 300;     //  out of range

                sbyte sb = -100; // Valid (-128 to 127)
                Console.WriteLine($"SByte Value: {sb}");
                Console.WriteLine($"SByte Min: {sbyte.MinValue}, Max: {sbyte.MaxValue}");
                Console.WriteLine($"SByte Size: {sizeof(sbyte)}");

                // sbyte sbError = 200;    // out of range


                Console.WriteLine("\n========= CHAR =========");

                char ch = 'A';
                Console.WriteLine($"Char: {ch}");
                Console.WriteLine($"Char ASCII: {(int)ch}");
                Console.WriteLine($"Char Min: {(int)char.MinValue}, Max: {(int)char.MaxValue}");
                Console.WriteLine($"Char Size: {sizeof(char)}");

                // char chError = 'AB';   // too many characters


                Console.WriteLine("\n========= STRING =========");

                string str = "Hello";
                Console.WriteLine($"String: {str}");
                Console.WriteLine($"Length: {str.Length}");
                Console.WriteLine($"Size in Bytes: {str.Length * sizeof(char)}");

                // string is reference type
                Console.WriteLine($"Default string: {default(string) ?? "null"}");


                Console.WriteLine("\n========= SIGNED INTEGERS =========");

                //short s = 100;
                //int i = 100000;
                //long l = 10000000000;

                Console.WriteLine($"Short Min: {short.MinValue}, Max: {short.MaxValue}");
                Console.WriteLine($"Int Min: {int.MinValue}, Max: {int.MaxValue}");
                Console.WriteLine($"Long Min: {long.MinValue}, Max: {long.MaxValue}");

                Console.WriteLine($"Short Size: {sizeof(short)}");
                Console.WriteLine($"Int Size: {sizeof(int)}");
                Console.WriteLine($"Long Size: {sizeof(long)}");

                // short sError = 40000;  // out of range


                Console.WriteLine("\n========= UNSIGNED INTEGERS =========");

                //ushort us = 50000;
                //uint ui = 3000000000;
                //ulong ul = 100000000000;

                Console.WriteLine($"UShort Min: {ushort.MinValue}, Max: {ushort.MaxValue}");
                Console.WriteLine($"UInt Min: {uint.MinValue}, Max: {uint.MaxValue}");
                Console.WriteLine($"ULong Min: {ulong.MinValue}, Max: {ulong.MaxValue}");

                // ushort usError = -10;  // unsigned cannot store negative


                Console.WriteLine("\n========= FLOAT, DOUBLE, DECIMAL =========");

                float f = 1.1234567f;  // must add f
                double d = 1.12345678912345; // default double
                decimal m = 1.123456789123456789123456789m; // must add m

                Console.WriteLine($"Float: {f}");
                Console.WriteLine($"Double: {d}");
                Console.WriteLine($"Decimal: {m}");

                Console.WriteLine($"Float Size: {sizeof(float)}");
                Console.WriteLine($"Double Size: {sizeof(double)}");
                Console.WriteLine($"Decimal Size: {sizeof(decimal)}");

                // float fError = 1.23;   // need 'f' suffix


                Console.WriteLine("\n========= BOOL =========");

                bool isTrue = true;
                Console.WriteLine($"Bool: {isTrue}");
                Console.WriteLine($"Bool Size: {sizeof(bool)}");

                // bool boolError = 1;   // cannot assign number to bool


                Console.WriteLine("\n========= DEFAULT VALUES =========");

                Console.WriteLine($"Default int: {default(int)}");
                Console.WriteLine($"Default float: {default(float)}");
                Console.WriteLine($"Default bool: {default(bool)}");
                Console.WriteLine($"Default char: {(int)default(char)}");


                Console.WriteLine("\n========= TYPE CASTING =========");

                int number = 100;
                byte casted = (byte)number; // Explicit casting
                Console.WriteLine($"Casted int to byte: {casted}");

                // byte castError = 1000;  // without cast


                Console.WriteLine("\n========= PERFORMANCE TEST =========");

                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int x = 0; x < 10000000; x++)
                {
                    short a1 = 100;
                }
                sw1.Stop();
                Console.WriteLine($"Short Loop Time: {sw1.ElapsedMilliseconds} ms");

                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                for (int x = 0; x < 10000000; x++)
                {
                    decimal a2 = 100;
                }
                sw2.Stop();
                Console.WriteLine($"Decimal Loop Time: {sw2.ElapsedMilliseconds} ms");


                Console.WriteLine("\n========= POINTER (UNSAFE) =========");

              

                Console.ReadKey();
            }
 
        
    }
 }

