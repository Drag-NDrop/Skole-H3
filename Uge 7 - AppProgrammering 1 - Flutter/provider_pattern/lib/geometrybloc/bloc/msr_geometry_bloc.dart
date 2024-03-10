import 'dart:ffi';
import 'dart:ui' as ui;
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:meta/meta.dart';
import 'dart:math';

part 'msr_geometry_event.dart';
part 'msr_geometry_state.dart';

class MsrGeometryBloc extends Bloc<MsrGeometryEvent, GeometryShape> {

  MsrGeometryBloc() : super(GeometryShape()..init()) {
    on<NewSquareEvent>((event, emit) =>    emit(state.newSquare()));
    on<NewTriangleEvent>((event, emit) =>  emit(state.init()));
    on<NewCircleEvent>  ((event, emit) =>  emit(state.newCircle()));
  }
}
