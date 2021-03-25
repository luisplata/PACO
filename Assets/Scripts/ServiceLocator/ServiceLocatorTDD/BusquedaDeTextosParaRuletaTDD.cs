using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BusquedaDeTextosParaRuletaTDD
    {
        // A Test behaves as an ordinary method
        [TestCase("Normal")]
        public void CuandoInicieElJuego_SeDebenCargarLosTextosDeLaRuleta(string genero)
        {
            //arrage
            IBuscadorDeTextosParaRuleta ruleta = new BusquedaDeCartasDesdeWebService("","","");
            
            //act
            List<ICarta> listaResultante = ruleta.BuscarTextosPorGenero(new Genero(genero));

            //assert
            Assert.IsTrue(listaResultante.Count > 0, "El problema es que no esta cargando nada");
            Assert.AreEqual(genero, listaResultante[0].Genero.Nombre, "El nombre que esta cargando no corresponde al solicitado");
        }
        
    }
}
