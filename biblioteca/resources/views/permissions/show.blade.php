@extends('layout')
@section('title', 'Permisos')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Permisos</a>
    </li>
@endsection
@section('thead')
    <th>ID</th>
    <th>Estado</th>
@endsection
@section('tbody')
    <tr>
        <th>{{$permission->PermissionsId}}</th>
        @if ($permission->State == 1)
            <th>Activo</th>
        @else
            <th>Inactivo</th>
        @endif
    </tr>
@endsection
