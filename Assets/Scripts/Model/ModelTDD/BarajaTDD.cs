using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BarajaTDD
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TomarCartaCuandoHayUna_DebeRetornarLaMismaCarta()
        {
            var texto = "texto";
            // arrange
            List<ICarta> cartas = new List<ICarta>
            {
                new Carta(new Genero("g"), texto)
            };
            var baraja = new Baraja(cartas);

            //Act
            var cartaElegida = baraja.TomarCarta();

            //assert
            Assert.AreEqual(texto, cartaElegida.Texto,"No esta entregando la carta respectiva");
        }

        [Test]
        public void TomarUnaCartaCuandoNoHayCartas_RetornaErrorEnUnaExcepcion()
        {
            var texto = "texto";
            // arrange
            List<ICarta> cartas = new List<ICarta>
            {
                new Carta(new Genero("g"), texto)
            };
            var baraja = new Baraja(cartas);

            //Assert
            Assert.Throws<NoHayCartasException>(() =>
            {
                var cartaElegida = baraja.TomarCarta();
                cartaElegida = baraja.TomarCarta();
            },"No esta lanzando la excepcion, porque todavia hay cartas que debieron ser eliminadas");
        }
    }
}
