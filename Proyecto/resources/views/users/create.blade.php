<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Crear / USUARIO</title>
</head>
<body>
    <h1>CREAR USUARIO</h1>

    <form method="POST" action="{{route('author.store')}}">
        @csrf
        <label>
            ID  <br>
             <input type="text" name="id" {{--value="{{ old('title',$project->title)}}  "--}} required>
        </label>
        <br>
        <label>
            NAME  <br>
            <input type="text" name="name" {{-- value="{{ old('url', $project->url) }}  "--}} required>
        </label>
        <br>
        <label>
            PASS  <br>
            <input type="password" name="pass" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            EMAIL  <br>
            <input type="email" name="email" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            PHONE  <br>
            <input type="text" name="phone" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <label>
            ESTADO  <br>
            <input type="number" name="state" {{-- value="{{ old('url', $project->url) }} "--}} required>
        </label>
        <br>
        <button type="submit">Guardar</button>
    </form>

</body>
</html>
