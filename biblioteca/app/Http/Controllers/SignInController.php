<?php

namespace App\Http\Controllers;
use App\Http\Controllers\BibliotecaController;
use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;

class SignInController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        //
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store()
    {
        //return request();
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
         ]);
        $response = $client->post('40.117.209.118/libraryapi/api/Security/LoginUser', [
            'body'=>json_encode([
                'username' => request('id'),
                'password' => request('password'),
            ])
         ]);
        $datos = json_decode($response->getBody()->getContents());

        $user = ''; $id = ''; $name =''; $roleId=''; $permisions =''; $vector[] = array();
        $permiso1 = ''; $permiso2 = ''; $permiso3 = '';
        foreach ($datos as $value) {
            foreach ($value as $data) {
                //dd($data);
                $user = with($data->Estado);
                $id = with($data->UserId);
                $name = with($data->UserName);
                $roleId = with($data->RoleId);


                $permisions = with($data->Permisision);

                foreach ($permisions as $permiso) {
                    $vector[] = $permiso->PermissionsId;
                    //print_r($permiso->PermissionsId);
                        // return json_decode($permiso->getBody()->getContents());

                }
            }
        }
        // return $permiso2;
        // return redirect()->view('/',[
        //     'user' => $user,
        //     'id' => $id,
        //     'name' => $name,
        //     'roleId' => $roleId,
        //     'permiso1' => $vector[1],
        //     'permiso2' => $vector[2],
        //     'permiso3' => $vector[3],
        //  ]);
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
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
