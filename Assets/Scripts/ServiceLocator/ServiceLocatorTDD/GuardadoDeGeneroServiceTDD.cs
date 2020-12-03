using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GuardadoDeGeneroServiceTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void GuardarGeneros_ConGenerosDefinidos()
        {
            IGuardadoDeGeneros pruebas = new GuardadoDeGeneroService();
            List<IGenero> generos = new List<IGenero>();
            for(var i = 0; i < 4; i++){
                generos.Add(new Genero(i.ToString()));
            };

            pruebas.GuardarGeneros(generos);

            Assert.AreEqual(4, pruebas.GenerosGuardados.Count);
            Assert.AreEqual("0", pruebas.GenerosGuardados[0].Nombre);
        }

        [Test]
        public void GuardadoDeGeneros_SinGeneroDefinidoDebeFallar()
        {
            IGuardadoDeGeneros pruebas = new GuardadoDeGeneroService();
            List<IGenero> generos = new List<IGenero>();

            Assert.Throws<ListaDeGenerosVaciaException>(() => {
                pruebas.GuardarGeneros(generos);
            });
        }
    }
}
