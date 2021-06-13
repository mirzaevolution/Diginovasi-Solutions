using System;
using System.Collections.Generic;

namespace Diginovasi.BusinessObjects.Masters
{
    public class Satuan
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public List<Material> Materials { get; set; } = new List<Material>();
    }
}
