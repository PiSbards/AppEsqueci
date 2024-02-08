﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEsqueci.Model
{
    [Table("Anotacoes")]
    public class ModelNotas
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Titulo{ get; set; }
        [NotNull]
        public String Dados{ get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        public ModelNotas()
        {
            this.Id = 0;
            this.Dados = "";
            this.Favorito = false;
            this.Titulo = "";
        }
    }
}
