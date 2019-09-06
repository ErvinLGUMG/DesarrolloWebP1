@extends('layout')
@section('title', 'Usuarios')
@section('thead')
    <th colspan="6" style="text-align:center">OPCIONES</th>
@endsection
@section('tbody')
    <tr>
        <td colspan="2" style="text-align:center">
            <a class="btn btn-success" href="{{ route('users.create') }}" role="button">Crear un usuario nuevo</a>
        </td>
        <td colspan="2" style="text-align:center">
            <a class="btn btn-primary" href="{{ route('users.edit',$user->UserId) }}" role="button">Actualizar este usuario</a>
        </td>
        <td colspan="2" style="text-align:center">
            <form method="POST" action="{{ route('users.delete',$user->UserId) }}">
                @csrf
                <button type="submit" class="btn btn-danger">Eliminar esta Usuario</button>
            </form>
        </td>
    </tr>

    <th style="text-align:center">ID</th>
    <th style="text-align:center">Nombre</th>
    <th style="text-align:center">Contrasenia</th>
    <th style="text-align:center">Email</th>
    <th style="text-align:center">Telefono</th>
    <th style="text-align:center">Estado</th>
    <tr>
        <td style="text-align:center">{{$user->UserId}}</td>
        <td style="text-align:center">{{$user->Name}}</td>
        <td style="text-align:center">{{$user->Password}}</td>
        <td style="text-align:center">{{$user->Email}}</td>
        <td style="text-align:center">{{$user->Telephone}}</td>
        @if ($user->State == 1)
            <td style="text-align:center">Activo</td>
        @else
            <td style="text-align:center">Inactivo</td>
        @endif
    </tr>
@endsection
