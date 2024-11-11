# Maquina-de-turing-Logica: Simulador de Máquina de Turing

## Descripción del Proyecto
Este proyecto implementa un simulador de Máquina de Turing determinista en Java. El programa puede leer especificaciones de máquinas de Turing desde archivos de texto y simular su ejecución, generando un archivo de salida con las configuraciones resultantes.

## Estructura del Proyecto
El proyecto consta de los siguientes componentes principales:

- `Machine.java`: Implementa la lógica principal de la Máquina de Turing
- `TuringMachineSimulation.java`: Clase principal que maneja la lectura de archivos y la ejecución
- Archivos:
  - `machine_accepted.txt`: Ejemplo de máquina que llega a estado de aceptación
  - `machine_rejected.txt`: Ejemplo de máquina que llega a estado de rechazo
  - `machine_loop.txt`: Ejemplo de máquina que entra en ciclo infinito
  - `machine_data.txt`: Contiene especificaciones adicionales de la máquina

## Formato del Archivo de Entrada
El archivo de entrada, machine_data.txt , debe seguir el siguiente formato:

```
[cadena_entrada]
[estados_separados_por_coma]
[alfabeto_entrada]
[alfabeto_pila]
[simbolo_blanco]
[estado_aceptacion]
[estado_rechazo]
[estado_inicial]
[transiciones]
```

Ejemplo de transiciones:
```
q1,0|q2,x,R
q1,U|qreject,U,R
```
Donde cada transición sigue el formato: `estado_actual,símbolo_actual|nuevo_estado,nuevo_símbolo,dirección`

## Funcionalidades

1. **Lectura de Especificaciones**
   - Lee la configuración de la máquina desde un archivo de texto
   - Valida el formato y los componentes de la máquina

2. **Simulación**
   - Procesa la cadena de entrada según las reglas especificadas
   - Detecta estados de aceptación, rechazo y ciclos infinitos
   - Limita la ejecución a 50 pasos para evitar ciclos infinitos reales

3. **Generación de Salida**
   - Crea un archivo `output.txt` con las configuraciones
   - Muestra el resultado de la ejecución (aceptación/rechazo)
   - Documenta el proceso paso a paso

## Cómo Ejecutar el Programa

1. Compilar los archivos Java:
```bash
javac TuringMachineSimulation.java Machine.java
```

2. Ejecutar el programa:
```bash
java TuringMachineSimulation
```

El programa leerá por defecto el archivo `machine_loop.txt`. Para cambiar el archivo de entrada, modificar la variable `path` en `TuringMachineSimulation.java`.

## Formato del Archivo de Salida
El archivo de salida (`output.txt`) contendrá:
- Configuraciones paso a paso de la máquina
- Estado final de la ejecución (Cadena aceptada/rechazada)
- En caso de ciclo, se mostrará un mensaje "*****Loop*****"


## Demostraciones 
#### Cadenas que quedan en Loop:
![alt text](<Imagen de WhatsApp 2024-11-10 a las 21.36.26_c5b02a0f.jpg>)

#### Cadenas rechazadas:
![alt text](<Imagen de WhatsApp 2024-11-10 a las 21.37.37_88c95ab5.jpg>)

#### Cadenas aceptadas 
![alt text](<Imagen de WhatsApp 2024-11-10 a las 21.38.25_3f4b2006.jpg>)