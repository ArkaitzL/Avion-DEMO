# Demo Técnica: Mecánicas de Juego

Este repositorio contiene una **demo técnica** que tiene como objetivo explorar y probar mecánicas específicas de juego. Estas demos no son proyectos completos ni juegos finales, sino ejemplos funcionales diseñados para experimentar con conceptos técnicos y de jugabilidad.

Cada demo está enfocada en una mecánica específica, con el objetivo de proporcionar un entorno simple y directo donde se pueda observar y probar su implementación.

---

## Demo: Vuelo de un Avión basado en Físicas

Esta demo permite probar la simulación del vuelo de un avión utilizando físicas realistas y controles básicos. Es ideal para entender los conceptos de movimiento y rotación en el espacio 3D.

### Controles
Los controles están diseñados para ofrecer un manejo intuitivo y una experiencia fluida:

- **W/S**: Subir o bajar el avión (control del cabeceo).
- **A/D**: Girar el avión hacia la izquierda o derecha (control del alabeo).
- **Q/E**: Inclinación lateral del avión (control de guiñada).
- **Shift**: Aumentar la velocidad (acelerar).
- **Control**: Reducir la velocidad (frenar).
- **Espacio**: Soltar la carga.
- **Tab**: Cambiar entre diferentes cámaras (vista del avión, vista en tercera persona, etc.).

### Características Principales
- Implementación de físicas para un vuelo realista.
- Simulación de los tres tipos de rotaciones principales del avión:
  - **Cabeceo** (Pitch): Controlado con W/S.
  - **Alabeo** (Roll): Controlado con A/D.
  - **Guiñada** (Yaw): Controlado con Q/E.
- Mecánica de carga: La posibilidad de soltar carga con la tecla **G**.
- Cámaras dinámicas para mejorar la experiencia de prueba.

### Cómo Ejecutar
1. Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com/tuusuario/demo-vuelo-avion.git
