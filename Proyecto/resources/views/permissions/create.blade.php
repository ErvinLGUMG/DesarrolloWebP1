<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Crear / Permiso</title>
</head>
<body>
    <h1>CREAR PERMISO</h1>

    <form method="POST" action="{{route('permissions.store')}}">
        @csrf
        <label>
            ID del Permiso <br>
             <input type="text" name="id" value="PRB" {{--value="{{ old('title',$project->title)}}  "--}} required>
        </label>
        <br>
        <label>
            Nombre del Permiso <br>
            <input type="text" name="name" value="PRB" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            Estado del Permiso <br>
            <input type="number" name="state" value="0" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <button type="submit">Guardar</button>
    </form>

</body>
</html>
