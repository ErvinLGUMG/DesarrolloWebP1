<?php

namespace App\Http\Controllers;

use App\Permission;
use Illuminate\Http\Request;
use App\Http\Requests\SavePermissionRequest;
use GuzzleHttp\Client;

use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class PermissionController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/ListPermissions');
        $permissions = $request->getBody();

        return view('permissions.index',['permissions' => json_decode($permissions)]);
    }

    public function create()
    {
        return view('permissions.create');
        // return view('permissions.create',[
        //     'permissions' => new Permission
        // ]);
    }

    public function store()
    {
        return request();
        // $client = new Client([
        //     'headers'=>['Content-Type' => 'application/json']
        //  ]);
        //  $response = $client->post('40.117.209.118/libraryapi/api/Security/CreatePermissions', [
        //     'body'=>json_encode([
        //         'PermissionsId' => request('id'),
        //         'Name' => request('name'),
        //         'State' => request('state')
        //     ])
        //  ]);
        //  return $response->getBody();
        //return redirect()->route('permissions.index');
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($PermissionsId)
    {
        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Security/Permissions?PermissionsId='.$PermissionsId);
        $permissions = $request->getBody()->getContents();

        $permissions = json_decode($permissions);
        foreach ($permissions as $value) {
            foreach ($value as  $permission) {
                $data = $permission;
            }
        }
        $permission = $data;
        return view('permissions.show', compact('permission'));
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
