@extends('layout')
@section('title', 'Usuarios')
@section('thead')
    <th colspan="6" style="text-align:center">OPCIONES</th>
@endsection
@section('tbody')
    <tr>
        <td colspan="2" style="text-align:center">
            <a class="btn btn-success" href="{{ route('editorials.create') }}" role="button">Crear editorial nueva</a>
        </td>
        <td colspan="2" style="text-align:center">
            <a class="btn btn-primary" href="{{ route('editorials.edit',$editorial->EditorialId) }}" role="button">Actualizar esta editorial</a>
        </td>
        <td colspan="2" style="text-align:center">
            <a class="btn btn-danger" href="{{ route('editorials.destroy',$editorial->EditorialId) }}" role="button">Eliminar esta editorial</a>
        </td>
    </tr>

    <th style="text-align:center">ID</th>
    <th colspan="3" style="text-align:center">Nombre</th>
    <th style="text-align:center">Pais</th>
    <th style="text-align:center">Estado</th>
    <tr>
        <td style="text-align:center">{{$editorial->EditorialId}}</td>
        <td colspan="3" style="text-align:center">{{$editorial->Name}}</td>
        <td style="text-align:center">{{$editorial->CountryId}}</td>
        @if ($editorial->State == 1)
            <td style="text-align:center">Activo</td>
        @else
            <td style="text-align:center">Inactivo</td>
        @endif
    </tr>
@endsection
