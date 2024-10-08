﻿using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ClipBoardPreTreatment.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal partial class AppHistory : ObservableValidator
    {
        public AppHistory()
        {
            HistoryItems.ListChanged += (_, _) =>
            {
                OnPropertyChanged(nameof(HistoryCount));
            };
        }

        /// <summary>
        /// 历史记录文件存储路径
        /// </summary>
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}History.json";

        /// <summary>
        /// 历史记录保存数量
        /// </summary>
        [ObservableProperty]
        [property: JsonProperty]
        [property: System.ComponentModel.DataAnnotations.Range(0, 1000)]
        private int historySaveCountLimit = 100;

        /// <summary>
        /// 历史记录列表
        /// </summary>
        [property: JsonProperty]
        public BindingList<HistoryItem> HistoryItems { get; set; } = [];

        /// <summary>
        /// 历史记录数量
        /// </summary>
        public int HistoryCount => HistoryItems.Count;

        /// <summary>
        /// 序列化时自动截断
        /// </summary>
        /// <param name="context"></param>
        [OnSerializing]
        internal void OnOnSerializing(StreamingContext context)
        {
            HistoryItems = new BindingList<HistoryItem>(HistoryItems.Take(HistorySaveCountLimit).ToList());
        }
    }
}
