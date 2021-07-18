using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using myPersonalDict.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace myPersonalDict
{
    public class Translation
    {
        private SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public Translation( string dbPath )
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Translations>().Wait();
        }

        public async Task AddNewSentence(string textGerman, string textSpanish)
        {
            int result;
            try
            {
                if (string.IsNullOrEmpty(textGerman))
                    throw new Exception("German Sentence is empty");
                if (string.IsNullOrEmpty(textSpanish))
                    throw new Exception("Spanish Sentence is empty");

                Translations newTranslation = new Translations()
                { 
                    German = textGerman, 
                    Spanish = textSpanish
                };

                result = await conn.InsertAsync(newTranslation);
                StatusMessage = string.Format("Successful inserted. Result = {0}", result);
            }
            catch (Exception ex )
            {
                StatusMessage = string.Format("Failed to add. {0}", ex.Message);
            }
        }

        public async Task<List<Translations>> GetAllTranslations()
        {
            try
            {
                return await conn.Table<Translations>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive Data. {0}", ex.Message);
            }

            return new List<Translations>();
        }

        public async Task<List<Translations>> GetSearchedTranslations()
        {
            try
            {
                return await conn.QueryAsync<Translations>("SELECT * FROM Translations WHERE German = ?", "test%");
                //return result;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive Data. {0}", ex.Message);
            }

            return new List<Translations>();
        }
    }
}
