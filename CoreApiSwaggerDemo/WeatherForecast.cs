using System;

namespace CoreApiSwaggerDemo
{
    /// <summary>
    /// ����
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ����
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// �¶����϶�
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// �¶Ȼ��϶�
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        /// <summary>
        /// ˵��
        /// </summary>
        public string Summary { get; set; }
    }
}
