namespace RectangularTask.Application.Tasks.Dto
    {
    public class RectDto
        {
        #region <Rectangle Class Properties>

        public static RectDto rectDto = new RectDto();
        public int ID { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public string RectType { get; set; }
        public override string ToString()
            {
            return " Height: " + ID + " Width: " + Width + " Type : " + RectType + " Area:" + Area + " Perimeter:" + Perimeter;
            }

        #endregion
        }
    }
