using System;

namespace CoreApiSwaggerDemo
{
    /// <summary>
    /// 天气
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 温度摄氏度
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// 温度华氏度
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        /// <summary>
        /// 说明
        /// </summary>
        public string Summary { get; set; }
    }
}
