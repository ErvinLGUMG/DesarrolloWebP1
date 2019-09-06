@extends('layout')
@section('title', 'Roles')

@section('thead')
    <th>Roles</th>
@endsection
@section('tbody')

    @foreach ($roles as $item)
        @foreach ($item as $rol)
            <tr>
              <td>
                  <a href="{{ route('roles.show',$rol->RoleId)}}"> {{ $rol->Name }}</a>
                </td>
            </tr>
        @endforeach
    @endforeach

@endsection


