<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Crear / Autor</title>
</head>
<body>
    <h1>CREAR Autor</h1>

    <form method="POST" action="{{route('authors.store')}}">
        @csrf
        <label>
            ID del Autor <br>
             <input type="number" name="id" {{--value="{{ old('title',$project->title)}}  "--}} required>
        </label>
        <br>
        <label>
            Nombre del Autor <br>
            <input type="text" name="name" value="Autor de Pruebas" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            Pais del Autor <br>
            <input type="text" name="pais" value="BLR" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            Estado del Autor <br>
            <input type="number" name="state" value="1" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <button type="submit">Guardar</button>
    </form>

</body>
</html>
