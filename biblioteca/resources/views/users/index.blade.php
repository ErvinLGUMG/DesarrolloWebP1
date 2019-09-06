@extends('layout')
@section('title', 'Usuarios')

@section('lateral')
    <li class="nav-item">
            <a class="nav-link " href="#">Usuarios</a>
    </li>
@endsection

@section('thead')
    <th colspan="3" style="text-align:center">OPCIONES</th>
@endsection
@section('tbody')
    <tr>
        <td style="text-align:center"> <a class="btn btn-success" href="{{ route('users.create') }}" role="button">Crear un usuario nuevo</a> </td>
    </tr>
    <th colspan="3" style="text-align:center">USUARIOS</th>


    @foreach ($users as $item)
        @foreach ($item as $user)
            <tr>
              <td colspan="3" style="text-align:center">
                  <a href="{{ route('users.show',$user->UserId) }}"> {{ $user->Name }}</a>
                </td>
            </tr>
        @endforeach
    @endforeach

@endsection


