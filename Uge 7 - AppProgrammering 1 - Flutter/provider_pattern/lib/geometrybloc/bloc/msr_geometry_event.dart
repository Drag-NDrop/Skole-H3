part of 'msr_geometry_bloc.dart';

@immutable
sealed class MsrGeometryEvent {}

class NewSquareEvent extends MsrGeometryEvent {}

class NewTriangleEvent extends MsrGeometryEvent {}

class NewCircleEvent extends MsrGeometryEvent {}
