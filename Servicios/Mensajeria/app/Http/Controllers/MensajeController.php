<?php

namespace App\Http\Controllers;

use Validator;
use Illuminate\Support\Facades\DB;
use Illuminate\Http\Request;
use Illuminate\Http\Response;
use App\Http\Controllers\Controller;
use App\EstadoMensajeria;
use App\Mensajeria;
use App\Mensajeros;
use App\Modulos;
use App\ObservacionEntrega;
use App\ObservacionesMensajero;
use App\TrackingMensajeria;

class MensajeController extends Controller
{
    public function CrearMensaje(Request $rq)
    {
        $validar = Validator::make($rq->all(), [
            'modulo' => 'required',
            'usuario' => 'required',
            'contenido' => 'required',
            'ruta' => 'required',
        ]);

        if ($validar->fails()) {
            return response()->json($validar->messages(), 404);
        }

        $mensaje = Mensajeria::create($rq->all());

        if ($mensaje) {
            return [
                'codigo' => $mensaje->id,
                'success' => true
            ];
        }
    }
}
