@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Reportes</a>
    </li>
@endsection

@section('thead')
    <th style="text-align:center">Contenido</th>
@endsection

@section('tbody')
    {{-- <th colspan="3" style="text-align:center">USUARIOS</th> --}}
    @foreach ($authors as $item)
        @foreach ($item as $author)
                <tr>
                    <th style="text-align:center"> AUTOR: {{ $author->AuthorName }}</th>
                </tr>
            @foreach ($author->Books as $books)
                <tr>
                    <td style="text-align:center">LIBRO: {{ $books->Title }}</td>
                </tr>
            @endforeach
        @endforeach
    @endforeach

@endsection


