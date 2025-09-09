# change-span-count-based-on-screen-size-listview-xamarin
Change span count based on screen size listview xamarin

## Sample

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="*" />
    </Grid.RowDefinitions>

    <Grid x:Name="headerGrid" BackgroundColor="#FFEEEEF2" HeightRequest="45">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
            <code>
            . . .
            . . .
            <code>
    </Grid>

    <syncfusion:SfListView x:Name="listView"
                    SelectionMode="Multiple"
                    Grid.Row="1"
                    ItemSpacing="3">

        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                    <code>
                    . . .
                    . . .
                    <code>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>

        <syncfusion:SfListView.GroupHeaderTemplate>
            <DataTemplate>
                    <code>
                    . . .
                    . . .
                    <code>
            </DataTemplate>
        </syncfusion:SfListView.GroupHeaderTemplate>
    </syncfusion:SfListView>
</Grid>

C#:

if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
    gridLayout.SpanCount = Device.Idiom == TargetIdiom.Phone ? 2 : 4;
else if (Device.RuntimePlatform == Device.UWP)
{
    gridLayout.SpanCount = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 4 : 2;
    listView.ItemSize = Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet ? 230 : 140;
}
```
