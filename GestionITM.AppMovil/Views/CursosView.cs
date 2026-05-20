<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="GestionITM.AppMovil.Views.CursosView"
             Title="Catálogo de Cursos">
    
    <Grid Padding="15">
        <!-- Scroll Infinito configurado a 2 elementos antes de llegar al final -->
        <CollectionView ItemsSource="{Binding Cursos}"
                        RemainingItemsThreshold="2"
                        RemainingItemsThresholdReachedCommand="{Binding CargarMasCursosCommand}">
            
            <CollectionView.ItemTemplate>
                <DataTemplate>
                    <Frame Margin="0,0,0,12" Padding="15" CornerRadius="10" HasShadow="True">
                        <VerticalStackLayout>
                            <Label Text="{Binding Nombre}" FontSize="18" FontAttributes="Bold" />
                            <Label Text="{Binding Descripcion}" TextColor="DimGray" Margin="0,5,0,0" />
                            <Label Text="{Binding CuposDisponibles, StringFormat='Cupos: {0}'}" TextColor="#2B579A" FontAttributes="Bold" Margin="0,5,0,10" />
                            
                            <!-- El comando busca en el ViewModel padre el método de matricular -->
                            <Button Text="Matricularme" 
                                    Command="{Binding Source={RelativeSource AncestorType={x:Type CollectionView}}, Path=BindingContext.MatricularCommand}" 
                                    CommandParameter="{Binding Id}"
                                    BackgroundColor="#1976D2"
                                    TextColor="White"
                                    CornerRadius="5"/>
                        </VerticalStackLayout>
                    </Frame>
                </DataTemplate>
            </CollectionView.ItemTemplate>
            
        </CollectionView>
    </Grid>
</ContentPage>