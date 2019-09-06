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

    <form method="POST" action="{{route('roles.store')}}">
        @csrf
        <label>
            ID del ROL <br>
             <input type="text" name="id" {{--value="{{ old('title',$project->title)}}  "--}} required>
        </label>
        <br>
        <label>
            Nombre del ROL <br>
            <input type="text" name="name" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            Estado del ROL <br>
            <input type="number" name="state" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <button type="submit">Guardar</button>
    </form>

</body>
</html>
