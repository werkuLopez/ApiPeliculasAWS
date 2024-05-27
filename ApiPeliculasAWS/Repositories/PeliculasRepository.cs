using ApiPeliculasAWS.Data;
using ApiPeliculasAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculasAWS.Repositories
{
    public class PeliculasRepository
    {
        private PeliculasContext context;

        public PeliculasRepository(PeliculasContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelismysql>> GetPeliculas()
        {
            return await this.context.Pelismysqls.ToListAsync();
        }

        public async Task<List<Pelismysql>> GetPeliculasActores(string actores)
        {
            //List<Pelismysql> pelis = await GetPeliculas();

            //if (pelis.Count != 0)
            //{
            //    List<Pelismysql> filtered = await pelis.Where(x => pelis.Any(z => x.Actor.Contains(z))).ToList();

            //    return filtered;
            //}
            //else
            //{
            //    return null;
            //}


            List<Pelismysql> peliculas = await this.context.Pelismysqls.Where(x => x.Actor.Contains(actores)).ToListAsync();

            return peliculas;

        }


    }
}
