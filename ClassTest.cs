using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba9
{
    class ClassTest //основной класс
    {
   
        // поля класса
        double[,] mass; // массив с отложенной инициализацией
        double min,max;
        int n_leg, m_leg;
        int under,check_double;

        public ClassTest(int n, int m, double mn, double mx, int prov, int dob) // конструктор с 6-ю параметрами
        {
            check_double = dob; //инициализация переменных в конструкторе
            under = prov;
            min = mn;
            max = mx;
            n_leg = n;
            m_leg = m;
            mass = new double[n,m]; // инициализация массива
            mass_ini();
            // вызвать закрытый метод заполнения массива случ. числами
        }
        void mass_ini() //метод генерации рандомных значений
        {
            Random Rand = new Random(); // объявить объект класса (типа) Random
            if (check_double == 0 && max != min) //проверка на генерацию вещественных или целых чисел
            {
                Random Rand2 = new Random();
                int min_need = 0, max_need = 99;//мин. и макс. дробной части
                int min_need1 = 0, max_need1 = 99;//мин. и макс. дробной части для первого и последнего числа
                int n1, n2;//n1 - целая часть     n2 - дробная часть
                int min_int, max_int;//мин. и макс. для целой части
                    min_int = (int)min;//берём целое для мин.
                    min_need1 = Convert.ToInt32((min - min_int) * 100);//берём дробное. для мин.
                    max_int = (int)max;//берём целое для макс.
                    max_need1 = Convert.ToInt32((max - max_int) * 100);//берём дробное для макс.

                for (int j = 0; j < n_leg; j++)
                {
                    for (int i = 0; i < m_leg; i++)//цикл для заполнения числами с запятой
                    {
                        n1 = Rand.Next(min_int, max_int);//рандомная целая часть
                        n2 = Rand2.Next(min_need, max_need);//рандомная дробная часть
                        if (Convert.ToString(n2).Length == 1)
                        {
                            n2 = n2 * 10;
                        }
                        if (n1 == min_int && n2 < min_need1) //проверяем не получилось ли число меньше мин. по дробной части
                        {
                            n2 = Rand2.Next(min_need1, max_need); //если число меньше генерируем снова на основе дробной части мин. числа
                        }
                        if (n1 == max_int && n2 > max_need1) //проверяем не получилось ли число больше макс. по дробной части
                        {
                            n2 = Rand2.Next(min_need, max_need1); //если число больше генерируем снова на основе дробной части макс. числа
                        }
                        mass[j, i] = Convert.ToDouble(Convert.ToString(n1) + "," + Convert.ToString(n2)); //заполняем массив склеивавя целую и дробную часть
                    }

                }

            }
            else
            {
                for (int j = 0; j < n_leg; j++) //цикл для целых чисел
                {
                    for (int i = 0; i < m_leg; i++)
                    {
                        mass[j, i] = Rand.Next(Convert.ToInt32(min), Convert.ToInt32(max));
                    }
                }
            }
        }

        public string mass_get() //метод получения основного массива в виде строки
        {
            string ret = "";
            for (int j = 0; j < n_leg; j++)//цикл заполнения строки
            {
                for (int i = 0; i < m_leg; i++)
                {
                    if (under == 1)//проверяем на режим "ячеек"
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass[j, i])+"   ";
                    }
                }
                ret += "\n";
            }
            return ret;//возвращение строки
        }      
        public string mass_get_str_sr() //метод получения среднего арифметического по строчкам в обычном массиве
        {
            string ret = "";
            double sr_znach, a = 0; //переменные для вычисления ср. значения
            for (int j = 0; j < n_leg; j++)//циклы для расчёта среднего значения по строкам
            {
                for (int i = 0; i < m_leg; i++)
                {
                    a += mass[j, i];
                    if (under == 1)//проверка форматирования
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "   ";
                    }
                }
                sr_znach = a / m_leg;//считаем среднее
                a = 0;
                ret += " Среднее значение = " + String.Format("{0:f2}",sr_znach) + " \n";//в каждой строке выводим ср. значение
            }
            return ret;
        }
        public string mass_get_post_mult() //метод получения произведения чисел в строках
        {
            string ret = "";
            int chek = 0;
            double mult = 1;
            for (int j = 0; j < n_leg; j++)//цикл подсчёта произведения строк
            {
                mult = 1;
                for (int i = 0; i < m_leg; i++)
                {
                    if (mass[j, i] > 0) //проверяем элемент на положительность
                    {
                        mult = mult * mass[j,i];
                    }
                    else
                    {
                        chek = 1;
                    }
                    if (under == 1)//прроверка форматирования
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "  |";
                    }
                    else
                    {
                        ret += String.Format("{0,7:f}", mass[j, i]) + "   ";
                    }
                }
                    if (chek == 1)//если в строке был отрицательный элемент или 0 уведомляем об этом
                    {
                            ret += String.Format("{0,7:f}", "Есть отриц. число или 0");
                    }
                    else
                    {
                            ret += "Произв.= " + String.Format("{0,7:f}", mult) ;//выводим произведения
                    }                
                ret += " \n";
                chek = 0;
            }
            return ret;
        }       
    }
}
