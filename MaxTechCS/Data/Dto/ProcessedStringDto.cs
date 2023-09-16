﻿namespace MaxTechCS.Data.Dto
{
    public class ProcessedStringDto
    {
        public string Result { get; set; } = "";
        public Dictionary<char, int> CharsCount { get; set; } = new Dictionary<char, int>();
    }
}
