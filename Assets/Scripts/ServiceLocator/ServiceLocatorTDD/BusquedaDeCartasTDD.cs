using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BusquedaDeCartasTDD
    {
        // A Test behaves as an ordinary method
        [TestCase("Picante")]
        [TestCase("Normal")]
        public void BuscarCartasDesdeUnJson_ObjetoCargadoExitosamente(string genero)
        {
            //Arrage
            IBuscadorDeCartasGuardadas buscador = new BusquedaDeCartasDesdeWebService("","","");
            //Act
            List<ICarta> listaResultante = buscador.BuscarCartasPorGenero(new Genero(genero));
            //asert
            Assert.IsTrue(listaResultante.Count > 0,"El problema es que no esta cargando nada");
            Assert.AreEqual(genero, listaResultante[0].Genero.Nombre, "El nombre que esta cargando no corresponde al solicitado");
        }
        
    }
}
