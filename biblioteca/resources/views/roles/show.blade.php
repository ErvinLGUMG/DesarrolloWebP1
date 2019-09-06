@extends('layout')
@section('title', 'Rol')
@section('thead')
    <th>ID</th>
    <th>Nombre</th>
    <th>Estado</th>
@endsection
@section('tbody')
    <tr>
        <th>{{$rol->RoleId}}</th>
        <th>{{$rol->Name}}</th>
        @if ($rol->State == 1)
            <th>Activo</th>
        @else
            <th>Inactivo</th>
        @endif
    </tr>
@endsection
