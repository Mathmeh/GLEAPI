namespace GLEAPI.Dto
{
    public class RoutineCreateDto
    {
        public string Name { get; set; }
        public bool Publicity { get; set; }
        public int RoutineDuration { get; set; }// сколько месяцев предполагается выполнение рутины
        public string Motivation { get; set; }
    }
}
