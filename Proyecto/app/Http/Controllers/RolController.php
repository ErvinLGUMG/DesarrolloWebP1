<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use GuzzleHttp\Client;


class RolController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/ListRoles');
        $roles = $request->getBody();

        return view('roles.index',['roles' => json_decode($roles)]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create(Request $request)
    {
        // $response = $client->request('POST', '40.117.209.118/libraryapi/api/Security/CreateRol', [
        //     'form_params' => [
        //         'RoleId' => 'PRB',
        //         'Name' => 'PRUEBA',
        //         'State' => 1
        //     ]
        // ]);
        return $request;
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($Roleid)
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/Role?RoleId='.$Roleid);
        $roles = $request->getBody()->getContents();

        $roles = json_decode($roles);
        foreach ($roles as $value) {
            foreach ($value as  $rol) {
                $data = $rol;
            }
        }
        $rol = $data;
        return view('roles.show', compact('rol'));
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
}
