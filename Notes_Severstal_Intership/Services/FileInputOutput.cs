using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Notes_Severstal_Intership.Model;

namespace Notes_Severstal_Intership.Services
{
    internal class FileInputOutput
    {
        private readonly string PATH;

        public FileInputOutput(string path)
        {
            PATH = path;
        }

        public BindingList<NoteModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<NoteModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NoteModel>>(fileText);
            }
        }

        public void SaveData(object noteData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(noteData);
                writer.Write(output);
            }
        }
    }
}
