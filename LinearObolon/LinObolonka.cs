using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LinearObolon
{
    class LinObolonka: IEnumerable
    {
        private List<PointF> points;
        private List<PointF> output;

        public int Count
        {
            get { return output.Count; }
        }

        public LinObolonka(List<PointF> list)
        {
            points = new List<PointF>(list);
            output = new List<PointF>();
        }

        public LinObolonka()
        {
            points = new List<PointF>();
            output = new List<PointF>();
        }

        public void AddPoint(float x, float y)
        {
            points.Add(new PointF(x, y));
        }

        /**Початкова точка
         * Вибираємо точку з найменшою
         * Y-координатою
         * Якщо таких кілька, то вибираємо
         * серед тих з найменшою
         * Х-координатою
         */ 
        private PointF startPoint()
        {
            float min = points[0].Y;
            int index = 0;

            for(int i = 1; i < points.Count; ++i)
            {
                if(points[i].Y < min)
                {
                    min = points[i].Y;
                    index = i;
                }
                else
                {
                    if(points[i].Y == min)
                    {
                        if(points[i].X < points[index].X)
                        {
                            index = i;
                            min = points[i].Y;
                        }
                    }
                }
            }
            
            PointF buff = points[0];
            points[0] = points[index];
            points[index] = buff;

            return new PointF(points[0].X, points[0].Y);
        }

        /**Поворот
         * Визначає поворот від точки
         * Вліво чи вправо
         */ 
        private int vectorTurn(PointF p1, PointF p2, PointF p3)
        {
            float v = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
            return v > 0 ? 1 : ( v < 0 ? -1 : 0 );
        }

        /**Лінійна оболонка
         * Будуємо лінійну оболонку методом Грехема
         */ 
        public void createLinObolonka()
        {
            SortByAngle();

            output.Add(points[0]);
            output.Add(points[1]);

            int M = 2;

            for(int i = 2; i < points.Count;++i)
            {
                while(M > 1 && (vectorTurn(output[M-2], output[M-1], points[i]) < 0))
                {
                    output.Remove(output[M-1]);
                    --M;
                }

                ++M;

                output.Add(points[i]);
            }

            output.Add(points[0]);
        }

        /**Сортування по куту
         * Кут береться між прямою, яка складається з двох точок
         * І віссю ОХ
         */ 
        public void SortByAngle()
        {
            PointF p = startPoint();

            //MessageBox.Show(p.ToString());

            using (StreamWriter sw = new StreamWriter("text2.txt"))
            {
                for (int i = 1; i < points.Count; ++i)
                {
                    sw.WriteLine(myCtg(p, points[i]));
                }
            }

            for (int i = 1; i < points.Count; ++i)
            {
                double min;

                int indexMin;

                min = myCtg(p, points[i]);

                indexMin = i;

                for(int j = i + 1; j < points.Count; ++j)
                {
                    if(myCtg(p, points[j]) < min)
                    {
                        min = myCtg(p, points[j]);
                        indexMin = j;
                    }
                }

                PointF buff = points[i];
                points[i] = points[indexMin];
                points[indexMin] = buff;
            }

            using (StreamWriter sw = new StreamWriter("text.txt"))
            {
                for(int i = 1; i < points.Count; ++i)
                {
                    sw.WriteLine(myCtg(p, points[i]));
                }
            }
        }

        /**Обчислюємо кут
         * Арктангенс кута
         */ 
        public double myCtg(PointF start, PointF p)
        {
            return ((p.X - start.X) != 0.0 ? (Math.Atan2((p.Y - start.Y),(p.X - start.X))*180/Math.PI) : 0);
        }

        /**Очистка
         * Очищаємо всі лісти
         * з точками
         */
        public void clear()
        {
            points.Clear();
            output.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return points.GetEnumerator();
        }

        public PointF this[int i]
        {
            get { return output[i]; }
        }

        
    }
}
