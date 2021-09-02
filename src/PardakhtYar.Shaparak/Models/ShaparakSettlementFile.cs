﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PardakhtYar.Shaparak.Models {

    public class ShaparakSettlementFile {

        public ShaparakSettlementFile() 
            => SettlementDataDetails = new List<ShaparakSettlementData>();
        
        public IList<ShaparakSettlementData> SettlementDataDetails { get; set; }

        public void Add(ShaparakSettlementData settlementData) 
            => SettlementDataDetails.Add(settlementData);
        
        public void SaveToFile(string filename) {
            if(!SettlementDataDetails.Any())
                throw new ArgumentNullException("The Settlement Details cannot be empty.");

            var contents = ToJson();
            using var stream = new StreamWriter(filename);
            stream.Write(contents);
            stream.Flush();
            stream.Close();
        }

        public string ToJson() => this.SerializeToString();
        
    }
}
