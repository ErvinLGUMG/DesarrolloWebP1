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
    @foreach ($categories as $item)
        @foreach ($item as $category)
                <tr>
                    <th style="text-align:center"> CATEGORIA: {{ $category->CategoryName }}</th>
                </tr>
            @foreach ($category->Books as $books)
                <tr>
                    <td style="text-align:center">LIBRO: {{ $books->Title }}</td>
                </tr>
            @endforeach
        @endforeach
    @endforeach

@endsection


