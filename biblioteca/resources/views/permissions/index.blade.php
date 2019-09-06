@extends('layout')
@section('title', 'Permisos')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Permisos</a>
    </li>

@endsection

@section('thead')
    <th>Permisos</th>
    <th><a href="{{ route('permissions.create') }}">Crear Permiso</a></th>
@endsection
@section('tbody')

    @foreach ($permissions as $item)
        @foreach ($item as $permission)
            <tr>
              <td>
                  <a href="{{ route('permissions.show',$permission->PermissionsId)}}"> {{ $permission->Name }}</a>
                </td>
            </tr>
        @endforeach
    @endforeach

@endsection


