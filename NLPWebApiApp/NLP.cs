using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLPWebApiApp
{
    public class NLP
    {
        public string UserText { get; set; }

    }

    public class NLPResult
    {
        public string Output { get;  private set; }

        public string makeDigits(string phrase)
        {
            string[] words = phrase.Split(' ');

            int totalNumber = 0;
            int currentNumber = 0;

            foreach (var word in words)
            {
                string newWord = "";

                for (int i = 0; i < word.Length; i++)
                {
                    // kontrol edilen string
                    newWord += word[i];

                    // string tek karakter durumu
                    while (newWord.Length == 1)
                    {
                        // sayi mi kontrol et
                        if (Digits.Contains(newWord))
                        {
                            // sayiyla 1000 durumu
                            if (newWord == "1" && i+3 < word.Length)
                            {
                                if (word[i+1].ToString() == "0" && word[i+2].ToString() == "0" && word[i+3].ToString() == "0")
                                {
                                    newWord = "bin";
                                    i = i + 3;
                                    break;
                                }

                            }
                            // sayiyla 100 durumu
                            else if (newWord == "1" && i + 2 < word.Length)
                            {
                                if (word[i + 1].ToString() == "0" && word[i + 2].ToString() == "0")
                                {
                                    newWord = "yüz";
                                    i = i + 2;
                                    break;
                                }
                            }
                            else
                            {
                                currentNumber = digitsMethod(int.Parse(newWord), currentNumber);
                            }
                            /* if (currentNumber %10 == 0)
                            {
                                currentNumber += int.Parse(word);
                            }
                            else
                            {
                                currentNumber = currentNumber * 10 + int.Parse(word);
                            }*/

                            newWord = "";
                            break;

                        }
                        else break;
                        
                    }

                    // string iki karakter durumu
                    while (newWord.Length == 2)
                    {
                        if (newWord.ToLower() == "on")
                        {
                            totalNumber += 10;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "üç")
                        {
                            currentNumber = digitsMethod(3, currentNumber);
                            newWord = "";
                        }
                        else break;

                    }

                    // üç karakter durumu
                    while (newWord.Length == 3)
                    {
                        if (newWord.ToLower() == "bin")
                        {
                            if (totalNumber == 0 && currentNumber == 0)
                            {
                                totalNumber += 1000;
                                newWord = "";
                            }
                            else if (currentNumber == 0)
                            {
                                totalNumber = totalNumber * 1000;
                                newWord = "";
                            }
                            else if (totalNumber == 0 && currentNumber != 0)
                            {
                                totalNumber = currentNumber * 1000;
                                currentNumber = 0;
                                newWord = "";
                            }
                            else
                            {
                                totalNumber += currentNumber;
                                totalNumber *= 1000;
                                currentNumber = 0;
                                newWord = "";
                            }

                        }
                        else if (newWord.ToLower() == "yüz")
                        {
                            /*if (totalNumber == 0 && currentNumber == 0)
                            {
                                totalNumber += 100;
                                newWord = "";
                            }
                            else*/ 
                            if (currentNumber != 0)
                            {
                                totalNumber += currentNumber * 100;
                                currentNumber = 0;
                                newWord = "";
                            }
                            else
                            {
                                totalNumber += 100;
                                newWord = "";
                            }

                        }
                        else if (newWord.ToLower() == "bir")
                        {
                            totalNumber += 1;
                            newWord = "";

                        }
                        else if (newWord.ToLower() == "iki")
                        {
                            currentNumber = digitsMethod(2, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "beş")
                        {
                            currentNumber = digitsMethod(5, currentNumber);
                            newWord = "";
                        }
                        else break;

                    }

                    // dort karakter durumu
                    while (newWord.Length == 4)
                    {
                        if (newWord.ToLower() == "dört")
                        {
                            currentNumber = digitsMethod(4, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "altı")
                        {
                            currentNumber = digitsMethod(6, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "yedi")
                        {
                            currentNumber = digitsMethod(7, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "otuz")
                        {
                            totalNumber += 30;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "kırk")
                        {
                            totalNumber += 40;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "elli")
                        {
                            totalNumber += 50;
                            newWord = "";
                        }
                        else break;

                    }

                    // bes karakter durumu
                    while (newWord.Length == 5)
                    {
                        if (newWord.ToLower() == "sekiz")
                        {
                            currentNumber = digitsMethod(8, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "sıfır")
                        {
                            if (words[0] == newWord)
                            {
                                this.Output += "0";
                            }
                            else
                            {
                                this.Output += " " + "0";
                            }
                        }
                        else if (newWord.ToLower() == "dokuz")
                        {
                            currentNumber = digitsMethod(9, currentNumber);
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "yirmi")
                        {
                            totalNumber += 20;
                            newWord = "";
                        }
                        else break;

                    }

                    // alti karakter durumu
                    while (newWord.Length == 6)
                    {
                        if (newWord.ToLower() == "altmış")
                        {
                            totalNumber += 60;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "yetmiş")
                        {
                            totalNumber += 70;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "seksen")
                        {
                            totalNumber += 80;
                            newWord = "";
                        }
                        else if (newWord.ToLower() == "doksan")
                        {
                            totalNumber += 90;
                            newWord = "";
                        }
                        else break;

                    }

                    /*// kelimenin son karakteriyse ve son kelimeyse
                    if (i == word.Length-1 && words.Last() == word)
                    {
                        totalNumber += currentNumber;
                        currentNumber = 0;
                    }*/

                }

                
                // sayiya cevirecek bir sey olmadiysa outputa ayni sekilde yaz
                if (newWord == word && totalNumber + currentNumber == 0)
                {
                    // ilk kelimeyse bosluksuz basla
                    if (words[0] == word)
                    {
                        this.Output += word;
                    }
                    // degilse once bosluk birak
                    else
                    {
                        this.Output += " " + word;
                    }
                }
                // cevrilen kelimeden sonrasi cevrilmediyse
                else if (newWord == word && totalNumber + currentNumber != 0)
                {
                    totalNumber += currentNumber;

                    if (String.IsNullOrEmpty(this.Output))
                    {
                        this.Output = totalNumber.ToString() + " " + word;
                    }
                    else
                    {
                        this.Output += " " + totalNumber.ToString() + " " + word;
                    }
                    currentNumber = totalNumber = 0;
                }
                // son kelime cevrildiyse
                else if (words.Last() == word)
                {
                    totalNumber += currentNumber;
                    if (words[0] == word)
                    {
                        this.Output += totalNumber.ToString();
                    }
                    else
                    {
                        this.Output += " " + totalNumber.ToString();
                    }
                    currentNumber = 0;


                }

            }

            return this.Output;

            /*totalNumber += currentNumber;
            return totalNumber;*/

        }

        private static readonly string[] Digits = new[]
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        private int digitsMethod(int number, int currentNumber)
        {
            if (currentNumber % 10 == 0)
            {
                if (number == 0)
                {
                    currentNumber *= 10;
                }
                else
                {
                    currentNumber += number;
                }
            }
            else
            {
                currentNumber = currentNumber * 10 + number;
            }

            return currentNumber;
        }

    }
}
