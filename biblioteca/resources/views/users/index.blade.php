@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Usuarios</a>
    </li>
@endsection

@section('thead')
    <th>Usuarios</th>
    <th><a href="{{ route('users.create') }}">Crear USUARIO</a></th>
@endsection
@section('tbody')

    @foreach ($users as $item)
        @foreach ($item as $user)
            <tr>
              <td>
                  <a href="{{ route('users.show',$user->UserId)}}"> {{ $user->Name }}</a>
                </td>
            </tr>
        @endforeach
    @endforeach

@endsection


