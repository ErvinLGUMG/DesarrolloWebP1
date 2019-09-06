@extends('layout')
@section('title', 'Usuarios')
@section('thead')
    <th>ID</th>
    <th>Nombre</th>
    <th>Contrasenia</th>
    <th>Email</th>
    <th>Telefono</th>
    <th>Estado</th>
@endsection
@section('tbody')
    <tr>
        <th>{{$user->UserId}}</th>
        <th>{{$user->Name}}</th>
        <th>{{$user->Password}}</th>
        <th>{{$user->Email}}</th>
        <th>{{$user->Telephone}}</th>
        @if ($user->State == 1)
            <th>Activo</th>
        @else
            <th>Inactivo</th>
        @endif
    </tr>
@endsection
