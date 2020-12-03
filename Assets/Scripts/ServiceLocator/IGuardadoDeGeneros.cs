using System.Collections.Generic;

public interface IGuardadoDeGeneros
{
    void GuardarGeneros(List<IGenero> generos);
    List<IGenero> GenerosGuardados { get; }
}