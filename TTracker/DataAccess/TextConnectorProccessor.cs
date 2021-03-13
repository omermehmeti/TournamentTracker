using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using TTracker.Models;

namespace TTracker.DataAccess.TextHelper
{
    public static class TextConnectorProccessor
    {
        // load text file
        // covert text to list of prize model
        // find the max  id 
        /// ad a new record with new id = max+1
        /// convert prizes to a list of string 
        /// save list of strings to text file
        
        
        public static string FullFilePath(this string filename)
        {
            // 
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{filename}";
        }
        public static List<string> LoadFile(this string fullfilepath)
        {
            if (!File.Exists(fullfilepath))
            {
                return new List<string>();
            }
            return File.ReadAllLines(fullfilepath).ToList();
        }
        public static List<PrizeModel> ConverttoPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id =int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = double.Parse(cols[3]);
                p.PricePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> models ,string filename)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PricePercentage }");
            }
            File.WriteAllLines(filename.FullFilePath(), lines);
        }
    }
}
