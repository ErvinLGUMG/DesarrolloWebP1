<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Crear / Libro</title>
</head>
<body>
    <h1>CREAR libro</h1>

    <form method="POST" action="{{route('books.store')}}">
        @csrf
        <label>
            title del libro <br>
             <input type="text" name="title" {{--value="{{ old('title',$project->title)}}  "--}} required>
        </label>
        <br>
        <label>
            descripcion del libro <br>
            <input type="text" name="description" value="libro de Pruebas" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            imagen path libro <br>
            <input type="text" name="imagen" value="BLR" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            pdf path del libro <br>
            <input type="text" name="pdf" value="1" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            categoria ID <br>
            <input type="number" name="category" value="1" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            Autor ID <br>
            <input type="number" name="author" value="1" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            Editorial ID <br>
            <input type="number" name="editorial" value="1" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <button type="submit">Guardar</button>
    </form>
</body>
</html>
